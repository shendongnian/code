    [AttributeUsage(System.AttributeTargets.Class)]
    public sealed class ProjectionTypeNameAttribute : Attribute
    {
      private string m_Name;
      
      public string Name
      {
        get { return m_Name; }
      }
      public ProjectionTypeNameAttribute(string name)
      {
        m_Name = name;
      }
    }
    [ProjectionTypeNameAttribute(ProjectionWhatever.PROJECTION_NAME)]
    public class ProjectionWhatever
    {
      public const string PROJECTION_NAME = "Whatever";
      // if you want to have property as well
      public string ProjectionTypeName
      {
        get
        {
          return PROJECTION_NAME;
        }
      }
    }   
    // query if type has attribute
    var type = typeof(ProjectionWhatever);
    var attributes = type.GetCustomAttributes(typeof(ProjectionTypeNameAttribute), false);
    if (attributes != null && attributes.Length > 0)
    {
      var attribute = (ProjectionTypeNameAttribute)attributes[0];
      // use attribute.Name
    }    
