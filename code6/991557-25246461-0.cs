                using (UserPrincipal user = UserPrincipal.FindByIdentity(pc, "Doe, John"))
                {
                    Console.Out.Write(user.Enabled);
                }
            }`
