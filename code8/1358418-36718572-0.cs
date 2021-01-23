    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    namespace test.ViewModel
    {
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string[] words;
        private string currentWord;
        private string copyCurrentWord;
        private string displayWordInTextbox;
        public string DisplayWordInTextbox
        {
            get
            {
                return displayWordInTextbox;
            }
            set
            {
                displayWordInTextbox = value;
                NotifyPropertyChanged("DisplayWordInTextbox");
            }
        }
        public MainWindowViewModel()
        {
            buttonClick = new RelayCommand(buttonFunction);
            loadWordsFromFile();
            selectWord();
            displayWord();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private ICommand buttonClick;
        public ICommand ButtonClick
        {
            get
            {
                return buttonClick;
            }
            set
            {
                buttonClick = value;
            }
        }
        void buttonFunction(object obj)
        {
            string buttonContent = obj.ToString();
            if (currentWord.Contains(buttonContent) || currentWord.Contains(buttonContent.ToUpper()))
            {
                char[] temp = copyCurrentWord.ToCharArray();
                char[] findWord = currentWord.ToCharArray();
                char guessChar = buttonContent.ElementAt(0);
                for (int i = 0; i < findWord.Length; i++)
                {
                    if (findWord[i] == guessChar || findWord[i] == Char.ToUpper(guessChar))
                    {
                        temp[i] = findWord[i];
                    }
                    
                }
                copyCurrentWord = new string(temp);
                displayWord();
            }
        }
        private void loadWordsFromFile()
        {
            words = new string [] {"cat", "dog"};
        }
        private void selectWord()
        {
            int randomWordIndex = (new Random()).Next(words.Length);
            currentWord = words[randomWordIndex];
            char[] currentWordArray = currentWord.ToArray();
            bool isWord = false;
            for (int i = 0; i < currentWord.Length; i++)
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (currentWordArray[i] == c || currentWordArray[i] ==     Char.ToUpper(c))
                    {
                        isWord = true;
                    }
                }
                if (isWord == true)
                {
                    copyCurrentWord += "_";
                    isWord = false;
                }
                else
                {
                    copyCurrentWord += currentWordArray[i];
                }
            }
            words = words.Where(w => w != words[randomWordIndex]).ToArray();
        }
        private void displayWord()
        {
            displayWordInTextbox = "";
            for (int i = 0; i < copyCurrentWord.Length; i++)
            {
                displayWordInTextbox += copyCurrentWord.Substring(i, 1);
                displayWordInTextbox += " ";
            }
        }
      }
    }
