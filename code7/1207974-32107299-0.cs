    public interface IProjectTask
    {
	    Task GetTaskById(int id);
    }
    public enum ProjectTaskTypes
    {
	    MS = 1,
	    TL = 2,
	    ET = 3
    }
    public class ProjectTaskFactory
    {
	    public static IProjectTask GetInstance(ProjectTaskTypes projectTaskType,
                                               int projectTaskId)
	    {
		    IProjectTask task;
		    switch(projectTaskType)
		    {
			    case ProjectTaskTypes.MS:
        	    	task = new MSProjectTask(projectTaskId);
        	    	break;
    		    case ProjectTaskTypes.TL:
        		    task = new TLProjectTask(projectTaskId);
        		    break;
    		    case ProjectTaskTypes.ET:
        		    task = new ETProjectTask(projectTaskId);
        		    break;
    		    default:
        		    // throw error
		    }		
		    return task;
	    }
    }
    //usage
    var projectTask = ProjectTaskFactory.GetInstance(type);
    projectTask.ToModel()
