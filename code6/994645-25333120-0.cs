    // -------------------------
    // add this class:
    public class Changeable<T>
    {
        public T Value { get; set; }
    }
    // -------------------------
    // set up registrations like so:
    // register the default value like so
    builder.RegisterInstance(
        new Changeable<UserModel>
        {
            Value = new UserModel
                {
                    Id = Migration001.GuestUserId,
                    Email = Migration001.GuestEmail,
                    PasswordHash = Migration001.GuestPassword
                }
         });
    // register UserModel directly, which can be used by all the classes that don't
    // need to change the instance
    builder.Register(c => c.Resolve<Changeable<UserModel>>().Value);
