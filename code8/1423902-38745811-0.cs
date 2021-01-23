    public class Item
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Nazwa przedmiotu")]
        [Required(ErrorMessage = "Nazwa przedmiotu jest wymagana.")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Kategoria jest wymagana.")]
        public string Kategoria { get; set; }
        public string Magazyn { get; set; }
        [Required(ErrorMessage = "Kod jest wymagany.")]
        public string Kod { get; set; }
        [Display(Name = "Ilość zakupiona")]
        //[Required(ErrorMessage = "Ilość ogólna jest wymagana.")]
        public double Ilosc_zakupiona { get; set; }
        [Display(Name = "Ilość wypożyczona")]
        //[Required(ErrorMessage = "Ilość wypożyczona jest wymagana.")]
        public double Ilosc_wypozyczona { get; set; }
        [Display(Name = "Ilość magazynowa")]
        //[Required(ErrorMessage = "Ilość magazynowa jest wymagana.")]
        public double Ilosc_magazynowa { get; set; }
        [Display(Name = "Ilość zużyta")]
        //[Required(ErrorMessage = "Ilość zużyta jest wymagana.")]
        public double Ilosc_zuzyta { get; set; }
        [Display(Name = "Straty")]
        //[Required(ErrorMessage = "Straty są wymagane.")]
        public double Straty { get; set; }
        public string Sektor { get; set; }
        [Display(Name = "Półka")]
        public string Polka { get; set; }
        [Display(Name = "Pojemnik")]
        public string Pojemnik { get; set; }
    }
