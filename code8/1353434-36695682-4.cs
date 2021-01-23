    using System.Collections.Generic;
    public class Question {
        public string question;
        public string[] answer;
        public int correctAnswer;
        public Question(string question, string[] answer, int correctAnswer) {
            this.question = question;
            this.answer = answer;
            this.correctAnswer = correctAnswer;
        }
    }
    //this could also be part of your monobehaviour, i just like things seperate
    public class QuestionCollection {
        List<Question> questions;
        public QuestionCollection() {
            questions = new List<Question>();
        }
        public void AddQuestion(string question, string[] answers, int     correctAnswer) {
            questions.Add(new Question(question, answers, correctAnswer));
        }
        //here's where you get your random question
        public Question GetRandomQuestion() {
            //if theres any questions
            if(questions.Count > 0) {
                //we get a random index
                int randomIndex = Random.Range(0, questions.Count);
                //temporarily store the corresponding question
                Question q = questions[randomIndex];
                //remove it from the collection so it doesnt come up twice
                questions.RemoveAt(randomIndex);
                //and return it to the caller
                return q;
            }
           //there was no questions (either none has been added or were done) so we return null
           return null;
       }
    }
