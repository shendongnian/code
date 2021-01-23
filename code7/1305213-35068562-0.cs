    public class ScriptVersion
    {
    	private ScriptVersion _nextVersion;
    	private ScriptVersion _previousVersion;
    
    	public Guid ScriptVersionId { get; set; }
    	public Guid ScriptId { get; set; }
    	public string Body { get; set; }
    	public DateTime CreatedDate { get; set; }
    	public User CreatedBy { get; set; }
    
    	public ScriptVersion NextVersion
    	{
    		get { return _nextVersion; }
    		set
    		{
    			_nextVersion = value;
    			if (_nextVersion != null && _nextVersion.PreviousVersion != this)
    			{
    				_nextVersion.PreviousVersion = this;
    			}
    		}
    	}
    
    	public ScriptVersion PreviousVersion
    	{
    		get { return _previousVersion; }
    		set
    		{
    			_previousVersion = value;
    			if (_previousVersion != null && _previousVersion.NextVersion != this)
    			{
    				_previousVersion.NextVersion = this;
    			}
    		}
    	}
    
    	internal ScriptVersion InternalNextVersion
    	{
    		get { return NextVersion; }
    	}
    
    	internal ScriptVersion InternalPreviousVersion
    	{
    		get { return PreviousVersion; }
    	}
    }
