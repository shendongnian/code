        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UxEntry<bool>, Entry<bool>>();
                cfg.CreateMap<CallScheduleProfile, CallScheduleProfileViewModel>();
            });
            var old = new CallScheduleProfile();
            var newmodel = Mapper.Map<CallScheduleProfile, CallScheduleProfileViewModel>(old);
            Console.WriteLine(newmodel.Title.Value);
            Console.WriteLine(newmodel.Title.FriendlyName);
            Console.ReadKey();
            Console.WriteLine(newmodel.Title.FriendlyName);
            Console.ReadKey();
        }
