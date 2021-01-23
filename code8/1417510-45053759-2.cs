    public class BlogSpec : SpecificationBase<Blog>
    	{
    		readonly int _blogId;
    		private readonly List<object> _nestedObjects;
    
    		public ChallengeSpec(int blogid, List<object> nestedObjects)
    		{
    			this._blogId = blogid;
    			_nestedObjects = nestedObjects;
    		}
    
    		public override Expression<Func<Challenge, bool>> SpecExpression
    		{
    			get { return blogSpec => blogSpec.Id == this._blogId; }
    		}
    
    		public override List<Expression<Func<Blog, object>>> IncludeExpression()
    		{
    			List<Expression<Func<Blog, object>>> tobeIncluded = new List<Expression<Func<Blog, object>>>();
    			if (_nestedObjects != null)
    				foreach (var nestedObject in _nestedObjects)
    				{
    					if (nestedObject is Rules)
    					{
    						Expression<Func<Blog, object>> expr = blog => blog.Rules;
    						tobeIncluded.Add(expr);
    					}
    					
    				}
    
    			return tobeIncluded;
    		}
