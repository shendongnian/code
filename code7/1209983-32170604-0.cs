            Delegate validationDelegate;
            try
            {
                Type prog = assembly.GetType("DelegatesSampleApplication.Program");
                Type delegateType = assembly.GetType("DelegatesSampleApplication.IsPromotable");
                // Convert the Arg1 argument to a method
                MethodInfo mi = prog.GetMethod("EnableToPromote",
                BindingFlags.Public | BindingFlags.Static);
                // Create a delegate object that wraps the static method
                validationDelegate = Delegate.CreateDelegate(delegateType, mi);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Phew... not working" );
                return;
            }
