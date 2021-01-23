    [HttpDelete]
    // DELETE api/users/kmader
    public IHttpActionResult Delete(string id)
    {
        if (id == null || id == String.Empty)
        {
            return BadRequest("Invalid id");
        }
        var ldap = new LdapHelper();
        UserDto user = null;
        try
        {
            user = ldap.Get(id);
            if (user == null)
            {
                // Don't disclose that the user doesn't exist
                return BadRequest("Invalid id");
            }
            return ldap.Delete(user);
        }
        // Return an error specific to the exception caught
        // For example, no permissions to delete users
        catch (LDAPException ldapex)
        {
             return Request.CreateResponse(HttpStatusCode.ServerError, "Permission denied");
        }
        catch (Exception ex)
        {
            return Request.CreateResponse(HttpStatusCode.ServerError, "Generic LDAP failure");
        }
    }
