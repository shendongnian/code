	using Microsoft.AspNet.Identity;
	using System;
	namespace ProudSourcePrime.Identity
	{
		/// <summary>
		/// Class that implements ASP.NET Identity IUser interface.
		/// </summary>
		public class IdentityUser : IUser
		{
			public string Id { get; set; }
			public string UserName { get; set; }
			public virtual string Email { get; set; }
			public virtual string PasswordHash { get; set; }
			public virtual string SecurityStamp { get; set; }
			public virtual string PhoneNumber { get; set; }
			public virtual bool PhoneNumberConfirmed { get; set; }
			public virtual bool TwoFactorEnabled { get; set; }
			public virtual DateTime? LockoutEnabled { get; set; }
			public virtual int AccessFailedCount { get; set; }
			public virtual string Name { get; set; }
			/// <summary>
			/// Default constructor that generates a new guid.
			/// </summary>
			public IdentityUser()
			{
				Id = Guid.NewGuid().ToString();
			}
			/// <summary>
			/// Constructor that accepts a Username as a parameter.
			/// </summary>
			/// <param name="userName"></param>
			public IdentityUser(string userName) : this()
			{
				UserName = userName;
			}
			/// <summary>
			/// Public accessor to this IdentityUsers GUID
			/// </summary>
			string IUser<string>.Id
			{
				get
				{
					return Id;
				}
			}
			/// <summary>
			/// Public accessor to this IdentityUsers UserName
			/// </summary>
			string IUser<string>.UserName
			{
				get
				{
					return UserName;
				}
				set
				{
					UserName = value;
				}
			}
		}
	}
