    public class MainViewModel : Conductor<Screen>.Collection.AllActive
    {
        private Genetic genetic;
        
        public Genetic CurrentGenetic
        {
            get { return genetic; }
            set
            {
                genetic = value;
                NotifyOfPropertyChange(nameof(CurrentGenetic));
            }
        }
    }
    public class Genetic : PropertyChangedBase 
    {
        private int generationCount;
        
        public int GenerationCout
        {
            get { return generationCount; }
            set
            {
                generationCount = value;
                NotifyOfPropertyChange(nameof(CurrentGenetic));
            }
        }
     }
     // example binding
     <TextBlock Text="{Binding Path=CurrentGenetic.GenerationCout }" />
     // or caliburn micro convention
     <TextBlock x:Name="CurrentGenetic_GenerationCout" />
