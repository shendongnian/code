        public interface IGroupCar
        {
            string CarName { get; set; }
            string CarColour { get; set; }
            string CarLink { get; set; }
        }
        public interface IGroupSport
        {
            string SportName { get; set; }
            string SportLocation { get; set; }
            string SportLink { get; set; }
        }
        public interface IGroupFood
        {
            string FoodName { get; set; }
            string FoodPrice { get; set; }
            string FoodLink { get; set; }
        }
        public class VMMyPage : IGroupCar, IGroupSport, IGroupFood
        {
            public string CarName { get; set; }
            public string CarColour { get; set; }
            public string CarLink { get; set; }
            public string SportName { get; set; }
            public string SportLocation { get; set; }
            public string SportLink { get; set; }
            public string FoodName { get; set; }
            public string FoodPrice { get; set; }
            public string FoodLink { get; set; }
            // Your custom view model properties          
        }
