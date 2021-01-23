	public bool ChangePassword(string username, string oldPassword, string newPassword, out ActiveDirectoryMembership.LogonError changePasswordLogonError)
	{
		try
		{
			using (var context = new PrincipalContext(ContextType.Domain, DomainServer, _ldapUsername, _ldapPassword))
			{
				
				using (var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username))
				{
					user.ChangePassword(oldPassword, newPassword);
					changePasswordLogonError = ActiveDirectoryMembership.LogonError.LogonSuccessful;
					return true;
				}
			}
		}
		catch (PrincipalOperationException pex)
		{
			if ((ActiveDirectoryMembership.LogonError)(pex.ErrorCode) == ActiveDirectoryMembership.LogonError.AccountLockedOut)
			{
				changePasswordLogonError = ActiveDirectoryMembership.LogonError.AccountLockedOut;
				return false;
			}
			else
				throw;
		}
		catch (PasswordException pwdEx)
		{
			Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.HandleException(pwdEx, Policies.WARNING_EXCEPTION_POLICY_NAME);
			//Look at the error message and attempt to parse out the HRESULT and map it to our LogonError enum
			//A complete list of Network Management Error codes is available here: http://msdn.microsoft.com/en-us/library/windows/desktop/aa370674(v=vs.85).aspx
			//The HRESULT is a hex value which will need to be converted to an int in order to be matched against the list of Error code values
			if (pwdEx.Message.Contains("HRESULT: 0x80070056"))
				changePasswordLogonError = ActiveDirectoryMembership.LogonError.LogonFailure;
			else if (pwdEx.Message.Contains("HRESULT: 0x800708C5"))
				changePasswordLogonError = ActiveDirectoryMembership.LogonError.PasswordDoesNotMeetComplexityRequirements;
			else
				throw;
		   
			return false;
		}
		catch (Exception)
		{
			throw;
		}
	}
