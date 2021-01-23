    public partial class TestCollection : Window
    {
      public ObservableCollection<Hero> Heros { get { return _heros; } set { _heros = value; } }
      private ObservableCollection<Hero> _heros = new ObservableCollection<Hero>();
      public TestCollection()
      {
         // Putting this here allows the collection to populate BEFORE the UI is initialized.
         // Init(); 
         InitializeComponent();
         // Putting it here is normal. The ItemsControl works, but the single TextBox binding will not.
         Init();
      }
      private void Init()
      {
         Hero hero;
         //Hero hero = new Hero("Bu Lv", 100, 88, 100, 30);
         //hero.HP = 88;
         hero = new Hero();
         hero.Name = "Bu Lv";
         _heros.Add(hero);
         //hero = new Hero("Fei Zhang", 100, 88, 100, 30);
         //hero.HP = 90;
         hero = new Hero();
         hero.Name = "Fei Zhang";
         _heros.Add(hero);
      }
    }
