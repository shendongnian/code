    public class Estimator{
         
          public int EstimatorId {get;set;}
          public int Value {get;set;}
          public int ContactId {get;set;}
          public Contact Contact {get;set;}
    }
    public class Contact {
          public int ContactId {get;set;}
          public ICollection<Estimator> SelectedEstimator { set; get; }   
    }
