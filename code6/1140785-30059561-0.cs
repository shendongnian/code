     //something generic that can be easily mocked and processed in a generic way
     //your implementation almost certainly won't look exactly like this...
     //but the point is that you should look for a common pattern with the input
     interface IInput
     {
         ReportTypeEnum EntityType{ get; set; } 
         int EntityId{ get; set; }
     }
     interface IReportTemplate 
     {
          //return something that can be bound to/handled generically.
          //for instance, a DataSet can be easily and dynamically bound to grid controls.
          //I'm not necessarily advocating for DataSet, just saying it's generic
          //NOTE: the guts of this can use a dynamically assigned
          //      data source for unit testing
          DataSet GetData(int entityId); 
     }
     //maybe associate report types with the enum something like this.
     [AttributeUsage (AttributeTargets.Field, AllowMultiple = false)]
     class ReportTypeAttribute
     {
        public Type ReportType{ get; set; }
        //maybe throw an exception if it's not an IReportTemplate  
        public ReportTypeAttribute(Type reportType){ ReportType = reportType; }
     }
     //it should be easy for devs to recognize that if they add an enum value,
     //they also need to assign a ReportType, thus your code is less likely to
     //break vs. having a disconnect between enum and the place where an associated
     //concrete type is assigned to each value
     enum ReportTypeEnum
     {
         [ReportType(typeof(ConcreteReportTemplate1))]
         ReportType1,
         [ReportType(typeof(ConcreteReportTemplate2))]
         ReportType2
     }
     static class ReportUtility
     {  
         public static DataSet GetReportData(IInput input)
         {
             var report = GetReportTemplate(input.EntityType);
             return report.GetData(input.EntityId);
         }
         private static IReportTemplate GetReportTemplate(ReportTypeEnum entityType)
         {
             //spin up report by reflecting on ReportTypeEnum and
             //figuring out which concrete class to instantiate
         }
     }
