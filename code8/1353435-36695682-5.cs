    public class GameManager : MonoBehaviour {
    public GameObject StartScreen;
    public GameObject QuestionScreen;
    public GameObject ResultsScreen;
    
    //those two are not needed anymore
    //public GameObject[] questions;
    //public static int CurrentQuestionIndex;
    
    //a reference to the collection containing all the questions
    QuestionCollection questions;
    //the current question, or null if everything has been asked
    Question currentQuestion;
    
    private void ShowstartScreen(){
        StartScreen.SetActive (true);
        QuestionScreen.SetActive (false);
        ResultsScreen.SetActive (false);    
    }
    private void ShowQuestionScreen(){
        StartScreen.SetActive (false);
        QuestionScreen.SetActive (true);
        ResultsScreen.SetActive (false);    
    }
    public void StartButtonHandler(){
        ShowQuestionScreen ();
    }
    public void RandomizeQuestion (){
        //get a new random question
        currentQuestion = questions.GetRandomQuestion();
    }
    public void DisplayQuestion(){
        if(currentQuestion != null) {
             //fill out your Panels with currentQuestion.question, currentQuestion.answer[#]
        }
        else {
             //there is no question left to be asked.
        }
    
    }
    void Start (){
    
        //create the collection
        questions = new QuestionCollection();
        //fill the collection using this scheme
        questions.AddQuestion("Was the question answered?", new string[] { "Yes", "No" }, 0);
    
        ShowstartScreen ();
    }
