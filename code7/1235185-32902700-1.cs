        public JsonResult CalculateTreeView() {
            var p1 = new People
            {
                Id = 1,
                Name = "Ram"
            };
            var p2 = new People
            {
                Id = 2,
                Name = "Hari"
            };
            var p3 = new People
            {
                Id = 3,
                Name = "Sam3"
            };
            var p4 = new People
            {
                Id = 4,
                Name = "Jon"
            };
            var p5 = new People
            {
                Id = 5,
                Name = "Smith"
            };
            var p6 = new People
            {
                Id = 6,
                Name = "Max"
            };
            var p7 = new People
            {
                Id = 7,
                Name = "Himanshu"
            };
            var p8 = new People
            {
                Id = 8,
                Name = "Jack"
            };
            var p9 = new People
            {
                Id = 9,
                Name = "Mad"
            };
            var p10 = new People
            {
                Id = 10,
                Name = "Jacky"
            };
            var p11 = new People
            {
                Id = 11,
                Name = "Anchor"
            };
            var p12 = new People
            {
                Id = 12,
                Name = "Dam"
            };
            var p13 = new People
            {
                Id = 13,
                Name = "Xyz"
            };
            var p14 = new People
            {
                Id = 14,
                Name = "History"
            };
            var p15 = new People
            {
                Id = 15,
                Name = "Java"
            };
            var p16 = new People
            {
                Id = 16,
                Name = "Blue"
            };
            var p17 = new People
            {
                Id = 17,
                Name = "Kali"
            };
            var p18 = new People
            {
                Id = 18,
                Name = "lon "
            };
            p14.Children.Add(p15);
            p14.Children.Add(p16);
            p14.Children.Add(p17);
            p14.Children.Add(p18);
            p12.Children.Add(p13);
            p9.Children.Add(p10);
            p9.Children.Add(p11);
            p8.Children.Add(p9);
            p8.Children.Add(p12);
            p8.Children.Add(p14);
            p7.Children.Add(p8);
            p5.Children.Add(p6);
            p4.Children.Add(p5);
            p2.Children.Add(p3);
            p2.Children.Add(p4);
            p1.Children.Add(p2);
            p1.Children.Add(p7);
            return Json(p1, JsonRequestBehavior.AllowGet);
        }
