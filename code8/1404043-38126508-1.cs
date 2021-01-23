    [Serializable]
    public class Question
    {
      #region Public Procedures
    
      /// <summary>
      ///   Create a question for your quiz
      /// </summary>
      public void CreateAQuestion(string theQ, string opt1, string opt2, string opt3, string theAnswer)
      {
        theQuestion = theQ;
        answerA = opt1;
        answerB = opt2;
        answerC = opt3;
        correctAnswer = theAnswer;
      }
    
      /// <summary>
      ///   write quiz questions to xmlFile
      /// </summary>
      /// <param name="q"></param>
      public void WriteToXmlFile(Question q)
      {
        //write data to the xml file
        var textWriter = new XmlSerializer(typeof (Question));
        var xmlFile = new StreamWriter(@"d:\qsFile.xml");
        textWriter.Serialize(xmlFile, q);
        xmlFile.Close();
      }
    
      #endregion
    
      #region Private Properties
    
      public string theQuestion { get; set; }
      public string answerA { get; set; }
      public string answerB { get; set; }
      public string answerC { get; set; }
      public string correctAnswer { get; set; }
    
      #endregion
    }
