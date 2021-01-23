    using System.ComponentModel.DataAnnotations;
    
    namespace Diary.DataAccess.Model
    {
    	// Accommodate EF database-first regeneration (required for webforms)
    
    	[MetadataType(typeof(UserDetailMetaData))]
    	public partial class UserDetail
    	{
    	}
    
    	// Add the Data-Annotation attribute to the Title model-property.
    
    	public class UserDetailMetaData
    	{
    		[MaxLength(40, ErrorMessage="Title must not be more than 40 characters long.")]
    		public string Title { get; set; }
    	}
    
    }
