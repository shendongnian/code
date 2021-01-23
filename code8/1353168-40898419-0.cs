	using System;
	using System.Data;
	using System.Data.SqlClient;
	using System.Security.Claims;
	using System.Threading.Tasks;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.Owin;
	using Microsoft.Owin;
	using Microsoft.Owin.Security;
	using System.Security.Cryptography;
	using System.Text;
	namespace ProudSourcePrime.Identity
	{
		/// <summary>
		/// Class that represents the Users table in our database.
		/// 
		/// It actually does not connect to our database anymore. 
		/// 
		/// The data it recives for this implementation comes from a service reference running on our data service server.
		/// </summary>
		/// <typeparam name="TUser"></typeparam>
		public class UserTable<TUser> where TUser : IdentityUser
		{
			/// <summary>
			/// sql query that will retrive the username of this user account, keying off of the userId
			/// </summary>
			/// <param name="userId"></param>
			/// <returns></returns>
			public string GetUserName(string userId)
			{
				string userName = null;
				// TODO : sql query that will retrive the username of this user account, keying off of the userId
				return userName;
			}
			/// <summary>
			/// sql query that will retrive the userId of this user account, keying off of the userName
			/// </summary>
			/// <param name="userName"></param>
			/// <returns></returns>
			public string GetUserId(string userName)
			{
				string userId = null;
				// TODO : sql query that will retrive the userId of this user account, keying off of the userName
				return userId;
			}
			/// <summary>
			/// sql query to get our user data
			/// </summary>
			/// <param name="userId"></param>
			/// <returns></returns>
			public TUser GetUserById(string userId)
			{
				TUser user = null;
				ServiceReference1.Service1Client ProudSoureService = new ServiceReference1.Service1Client();
				ServiceReference1.UserRecordComposite userComposite = ProudSoureService.get_UserById(userId);
				user = (TUser)Activator.CreateInstance(typeof(TUser));
				user.AccessFailedCount = userComposite.AccessFailedCount;
				user.Email = userComposite.Email;
				user.Id = userComposite.Id;
				user.LockoutEnabled = userComposite.LockoutEndDateUtc;
				user.Name = userComposite.Name;
				user.PasswordHash = userComposite.PasswordHash;
				user.PhoneNumber = userComposite.PhoneNumber;
				user.PhoneNumberConfirmed = userComposite.PhoneNumberConfirmed;
				user.SecurityStamp = userComposite.SecurityStamp;
				user.TwoFactorEnabled = userComposite.TwoFactorEnabled;
				user.UserName = userComposite.UserName;
				return user;
			}
			/// <summary>
			/// sql query to retrive user using username
			/// </summary>
			/// <param name="userName"></param>
			/// <returns></returns>
			public TUser GetUserByUserName(string userName)
			{
				TUser user = null;
				ServiceReference1.Service1Client ProudSourceService = new ServiceReference1.Service1Client();
				ServiceReference1.UserRecordComposite userComposite = ProudSourceService.get_UserByUserName(userName);
				user = (TUser)Activator.CreateInstance(typeof(TUser));
				user.AccessFailedCount = userComposite.AccessFailedCount;
				user.Email = userComposite.Email;
				user.Id = userComposite.Id;
				user.LockoutEnabled = userComposite.LockoutEndDateUtc;
				user.Name = userComposite.Name;
				user.PasswordHash = userComposite.PasswordHash;
				user.PhoneNumber = userComposite.PhoneNumber;
				user.PhoneNumberConfirmed = userComposite.PhoneNumberConfirmed;
				user.SecurityStamp = userComposite.SecurityStamp;
				user.TwoFactorEnabled = userComposite.TwoFactorEnabled;
				user.UserName = userComposite.UserName;
				return user;
			}
			/// <summary>
			/// sql query for password hash of this user keying off of the userId
			/// </summary>
			/// <param name="userId"></param>
			/// <returns></returns>
			public string GetPasswordHash(string userId)
			{
				return new ServiceReference1.Service1Client().get_PasswordHash(userId);
			}
			/// <summary>
			/// Sql command that actually created the user record and inserts into it the passwordHash, usernam and Guid Id.
			/// </summary>
			/// <param name="user"></param>
			/// <param name="passwordHash"></param>
			/// <returns></returns>
			public bool SetPasswordHash(TUser user, string passwordHash)
			{
				return new ServiceReference1.Service1Client().set_PasswordHash(user.Id, passwordHash, user.UserName, user.Name);
			}
			/// <summary>
			/// Sql command that actually creates the user record and inserts into it the passwordHash, and Guid Id.
			/// 
			/// No in use currently SetPasswordHash(TUser user, string passwordHash) gets called.
			/// </summary>
			/// <param name="userId"></param>
			/// <param name="passwordHash"></param>
			/// <returns></returns>
			public bool SetPasswordHash(string userId, string passwordHash)
			{
				bool result = false;
				//
				return result;
			}
			/// <summary>
			/// sql query that retrives the security stamp for this user record
			/// </summary>
			/// <param name="userId"></param>
			/// <returns></returns>
			public string GetSecurityStamp(string userId)
			{
				string securityStamp = null;
				// TODO : sql query that retrives the security stamp for this user record
				return securityStamp;
			}
			/// <summary>
			/// sql query that will update a Users table record with the given security stamp
			/// </summary>
			/// <param name="userId"></param>
			/// <param name="securityStamp"></param>
			/// <returns></returns>
			public bool SetSecurityStamp(string userId, string securityStamp)
			{
				bool result = false;
				// TODO : sql query that sets the security stamp of a user record
				return result;
			}
			/// <summary>
			/// sql query that inserts a new user into our data base
			/// </summary>
			/// <param name="user"></param>
			/// <returns></returns>
			public bool Insert(TUser user)
			{
				bool result = false;
				// TODO : sql query that inserts a new User entry
				return result;
			}
			/// <summary>
			/// sql query to delete this user from our table
			/// </summary>
			/// <param name="user"></param>
			/// <returns></returns>
			public bool Delete(TUser user)
			{
				bool result = false;
				// TODO : sql query to delete this user from our table
				return result;
			}
			/// <summary>
			/// sql query that will update our user record on our Users table
			/// </summary>
			/// <param name="user"></param>
			/// <returns></returns>
			public bool Update(TUser user)
			{
				bool result = false;
				// TODO : sql query that will update our user record on our Users table
				return result;
			}
		}
		/// <summary>
		/// Class that implements ASP.NET IUserPasswordStore, IUserSecurityStamp and IUserStore off of the concrete impemntations of IdentityUser's methods.
		/// </summary>
		/// <typeparam name="TUser"></typeparam>
		public class UserStore<TUser> : IUserStore<TUser>, IUserPasswordStore<TUser> where TUser : IdentityUser
		{
			/// <summary>
			/// Private resident that gives access to UserTable's concrete methods
			/// </summary>
			private UserTable<TUser> userTable;
			/// <summary>
			/// Default Constructor that initializes a new UserTable with connection to our data base.
			/// </summary>
			public UserStore()
			{
				userTable = new UserTable<TUser>();
			}
			/// <summary>
			/// Insert a new user into our Users table.
			/// </summary>
			/// <param name="user"></param>
			/// <returns></returns>
			public Task CreateAsync(TUser user)
			{
				if (user == null)
				{
					throw new ArgumentNullException("user");
				}
				// This is commented out for now
				//
				// New User is actually created in method SetPasswordHash(TUser user, string passwordHash).
				//userTable.Insert(user);
				return Task.FromResult<object>(null);
			}
			/// <summary>
			/// Delete a user from our Users table.
			/// </summary>
			/// <param name="user"></param>
			/// <returns></returns>
			public Task DeleteAsync(TUser user)
			{
				if (user == null)
				{
					throw new ArgumentNullException("user");
				}
				userTable.Delete(user);
				return Task.FromResult<object>(null);
			}
			void IDisposable.Dispose()
			{
				throw new NotImplementedException();
			}
			/// <summary>
			/// Retrives a user by using an Id.
			/// </summary>
			/// <param name="userId"></param>
			/// <returns></returns>
			public Task<TUser> FindByIdAsync(string userId)
			{
				if (string.IsNullOrEmpty(userId))
				{
					throw new ArgumentNullException("user");
				}
				return Task.FromResult(userTable.GetUserById(userId));
			}
			/// <summary>
			/// Find a user by using the username.
			/// </summary>
			/// <param name="userName"></param>
			/// <returns></returns>
			public Task<TUser> FindByNameAsync(string userName)
			{
				if (string.IsNullOrEmpty(userName))
				{
					throw new ArgumentNullException("TUser is null");
				}
				return Task.FromResult(userTable.GetUserByUserName(userName));
			}
			/// <summary>
			/// Returns the passwordhash for a given TUser
			/// </summary>
			/// <param name="user"></param>
			/// <returns></returns>
			public Task<string> GetPasswordHashAsync(TUser user)
			{
				if (user == null)
				{
					throw new ArgumentNullException("user");
				}
				return Task.FromResult(userTable.GetPasswordHash(user.Id));
			}
			/// <summary>
			/// Get the security stamp for a given TUser.
			/// </summary>
			/// <param name="user"></param>
			/// <returns></returns>
			public Task<string> GetSecurityStampAsync(TUser user)
			{
				if (user == null)
				{
					throw new ArgumentNullException("user");
				}
				return Task.FromResult(userTable.GetSecurityStamp(user.Id));
			}
			/// <summary>
			/// Verfies whether a given TUser has a password.
			/// </summary>
			/// <param name="user"></param>
			/// <returns></returns>
			public Task<bool> HasPasswordAsync(TUser user)
			{
				if (user == null)
				{
					throw new ArgumentNullException("user");
				}
				if (!string.IsNullOrEmpty(userTable.GetPasswordHash(user.Id)))
				{
					return Task.FromResult(true);
				}
				else
				{
					return Task.FromResult(false);
				}
			}
			/// <summary>
			/// Sets the password hash for a given TUser.
			/// </summary>
			/// <param name="user"></param>
			/// <param name="passwordHash"></param>
			/// <returns></returns>
			public Task SetPasswordHashAsync(TUser user, string passwordHash)
			{
				if (user == null)
				{
					throw new ArgumentNullException("user");
				}
				if(userTable.SetPasswordHash(user, passwordHash))
				{
					return Task.FromResult("true");
				}
				else
				{
					return Task.FromResult("false");
				}
			}
			/// <summary>
			/// This method will set the secrity stamp for a given TUser.
			/// </summary>
			/// <param name="user"></param>
			/// <param name="stamp"></param>
			/// <returns></returns>
			public Task SetSecurityStampAsync(TUser user, string stamp)
			{
				if (user == null)
				{
					throw new ArgumentNullException("user");
				}
				if(userTable.SetSecurityStamp(user.Id, stamp))
				{
					return Task.FromResult("true");
				}
				else
				{
					return Task.FromResult("false");
				}
			}
			/// <summary>
			/// This method will update a given TUser
			/// </summary>
			/// <param name="user"></param>
			/// <returns></returns>
			public Task UpdateAsync(TUser user)
			{
				if (user == null)
				{
					throw new ArgumentNullException("user");
				}
				if(userTable.Update(user))
				{
					return Task.FromResult("true");
				}
				else
				{
					return Task.FromResult("false");
				}
			}
		}
		/// <summary>
		/// Implementation of the UserManager class that will be handeling verification and 
		/// </summary>
		public class ApplicationUserManager : UserManager<IdentityUser>
		{
			/// <summary>
			/// Class instantiation.
			/// </summary>
			/// <param name="store"></param>
			public ApplicationUserManager(UserStore<IdentityUser> store) : base(store)
			{
				Store = store;
				this.PasswordHasher = new AppPassword();
				UserLockoutEnabledByDefault = false;
				// this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(10);
				// this.MaxFailedAccessAttemptsBeforeLockout = 10;
				UserValidator = new UserValidator<IdentityUser>(this)
				{
					AllowOnlyAlphanumericUserNames = false,
					RequireUniqueEmail = false
				};
				// Configure validation logic for passwords
				PasswordValidator = new PasswordValidator
				{
					RequiredLength = 6,
					RequireNonLetterOrDigit = false,
					RequireDigit = false,
					RequireLowercase = false,
					RequireUppercase = false,
				};
			}
			/// <summary>
			/// Override that actually uses the base layer implementation thus exposing it's funtionality through this object.
			/// </summary>
			/// <param name="user"></param>
			/// <returns></returns>
			public override System.Threading.Tasks.Task<IdentityResult> CreateAsync(IdentityUser user, string password)
			{
				return base.CreateAsync(user, password);
			}
		}
		/// <summary>
		/// Custom password hasher and hash comparison implementor.
		/// </summary>
		public class AppPassword : IPasswordHasher
		{
			/// <summary>
			/// Method that hashes passwords.
			/// </summary>
			/// <param name="password"></param>
			/// <returns></returns>
			public string HashPassword(string password)
			{
				using (SHA256 sha = SHA256Managed.Create())
				{
					byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(password.ToString()));
					StringBuilder hashSB = new StringBuilder();
					for (int i = 0; i < hash.Length; i++)
					{
						hashSB.Append(hash[i].ToString("x2"));
					}
					return hashSB.ToString();
				}
			}
			/// <summary>
			/// Method that compares a given password hash with an input password and compares the given password hash with the hash of the input password.
			/// </summary>
			/// <param name="hashedPassword"></param>
			/// <param name="providedPassword"></param>
			/// <returns></returns>
			public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
			{
				string providedPassword_hashed = HashPassword(providedPassword);
				if (hashedPassword.Equals(providedPassword_hashed))
				{
					return PasswordVerificationResult.Success;
				}
				else
				{
					return PasswordVerificationResult.Failed;
				}
			}
		}
	}
