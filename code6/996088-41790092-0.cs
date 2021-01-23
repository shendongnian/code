     class Program
    {
        static void Main(string[] args)
        {
            //0,1,2,3,4,5
            SetRating(0);
            SetRating(1);
            SetRating(2);
            SetRating(3);
            SetRating(4);
            SetRating(5);
        }
        private static void SetRating(short ratingValue)
        {
            short ratingPercentageValue = 0;
            switch (ratingValue)
            {
                case 0: ratingPercentageValue = ratingValue; break;
                case 1: ratingPercentageValue = ratingValue; break;
                default: ratingPercentageValue = (short)((ratingValue - 1) * 25); break;
            }
            string SelectedImage = @"d:\Trash\phototemp\IMG_1200.JPG";
            using (var imageTemp = System.Drawing.Image.FromFile(SelectedImage))
            {
                var rating = imageTemp.PropertyItems.FirstOrDefault(x => x.Id == 18246);
                var ratingPercentage = imageTemp.PropertyItems.FirstOrDefault(x => x.Id == 18249);
                rating.Value = BitConverter.GetBytes(ratingValue);
                rating.Len= rating.Value.Length;
                ratingPercentage.Value = BitConverter.GetBytes(ratingPercentageValue);
                ratingPercentage.Len = ratingPercentage.Value.Length;
                imageTemp.SetPropertyItem(rating);
                imageTemp.SetPropertyItem(ratingPercentage);
                imageTemp.Save(SelectedImage + "new" + ratingValue +".jpg");
            }
        }
    }
