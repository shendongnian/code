     using System.Web;
     using Entities;
     using DataAccess;
     namespace Business
     {
       public class BusinessLiftingStory
      {
        public bool insertLifting(LiftingStory obj)
        {
            DataLiftingStory dataLifting = DataLiftingStory();
            dataLifting.insertLifting(obj);
        }
       }
     }
