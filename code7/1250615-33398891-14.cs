    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Documents;
    namespace WpfApplication3.ViewModel
    {
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
        }
        private ICollection<Inline> _inlineList;
        public ICollection<Inline> InlineList
        {
            get { return _inlineList; }
            set { Set(() => InlineList, ref _inlineList, value); }
        }
        
        public RelayCommand SendClicked
        {
            get
            {
                return new RelayCommand(() =>
                {
                    InlineList = new List<Inline>
                    {
                        new Run("This is some bold text") { FontWeight = FontWeights.Bold },
                        new Run("Some more text"),
                        new Run("This is some text") { TextDecorations = TextDecorations.Underline }
                    };
                });
            }
        }
    }
    }
