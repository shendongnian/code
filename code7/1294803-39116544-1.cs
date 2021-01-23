            MyViewModel N1 = new MyViewModel();
            List<Employee> N2 = new List<Employee>()
            {
                new Employee { Id=1,FullName="sivaragu" },
                 new Employee { Id=2,FullName="siva" },
                      new Employee { Id=3,FullName="SENTHIL" }
            };
            ViewBag.MovieType = N2;
            return View();
            
        }
