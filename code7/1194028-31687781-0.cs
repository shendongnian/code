    class Human
    {
        public int HumanId { get; set; }
        
        public int LastFoodEatenId { get; set; }
        public virtual Food LastEatenFood { get; set; }
        
        public int FavoriteFoodId { get; set; }
        public virtual Food FavoriteFood { get; set; }
        
        public int CurrentlyDesiredFoodId { get; set; }
        public virtual Food CurrentlyDesiredFood { get; set; }
        
        public virtual ICollection<Toy> Toys { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
    class Food
    {
        public int FoodId { get; set; }
    }
    class Pet
    {
        public int PetId { get; set; }
        public int HumanOwnerId { get; set; }
    }
    class Toy
    {
        public int ToyId { get; set; }
        public int HumanOwnerId { get; set; }
    }
