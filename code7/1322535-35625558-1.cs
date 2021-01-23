    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace testWPFApplication
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private ObservableCollection<Question> _questions;
            private Question _selectedQuestion;
    
            public ObservableCollection<Question> Questions
            {
                get { return _questions; }
                set
                {
                    _questions = value;
                    OnPropertyChanged("Questions");
                }
            }
    
            public Question SelectedQuestion
            {
                get { return _selectedQuestion; }
                set
                {
                    _selectedQuestion = value;
                    OnPropertyChanged("SelectedQuestion");
                    OnSelectedQuestionChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void OnPropertyChanged(string strPropertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(strPropertyName));
                }
            }
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                Init();
    
            }
    
            private void Init()
            {
                CreateMockData();
            }
    
            private void CreateMockData()
            {
                if (Questions == null)
                {
                    Questions = new ObservableCollection<Question>();
                }
                else
                {
                    Questions.Clear();
                }
    
                for (int i = 1; i <= 5; i++)
                {
                    Question q = new Question
                    {
                        QuestionId = i,
                        QuestionDescription = "Sample Question " + i.ToString(),
                        IsYes = false,
                        IsNA = false,
                        IsNo = false
                    };
                    Questions.Add(q);
                }
            }
    
            private void OnSelectedQuestionChanged()
            {
                if(SelectedQuestion != null)
                {
                    
                }
            }
    
            private void btnCheckAnswers_Click(object sender, RoutedEventArgs e)
            {
                StringBuilder strQuestionAnswer = new StringBuilder();
                foreach (Question item in Questions)
                {
                    strQuestionAnswer.AppendLine(item.QuestionDescription + ":");
                    strQuestionAnswer.AppendLine("IsYes:" + item.IsYes);
                    strQuestionAnswer.AppendLine("IsNo:" + item.IsNo);
                    strQuestionAnswer.AppendLine("IsNA:" + item.IsNA);
                }
    
                MessageBox.Show(strQuestionAnswer.ToString());
            }
        }
    
        public class Question
        {
            public int QuestionId { get; set; }
    
            public string QuestionDescription { get; set; }
    
            public bool IsYes { get; set; }
    
            public bool IsNo { get; set; }
    
            public bool IsNA { get; set; }
        }
    }
