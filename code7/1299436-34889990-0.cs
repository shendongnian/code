     questionData = QuestionData.LoadFromText(questionDataXMLFile.text)
     var available = new List<Question>(questionData.question);
     ...
     }
     public Question GetNextQuestion()
     {
         if (available.Count == 0)
            available.AddRange(questionData.question);
        q = Random.Range(0, available.Count);
        currentQuestion = available[q];
        available.RemoveAt(q);
        return currentQuestion;
     }
