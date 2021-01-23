    public class GenericDictionary
    {
    	private IDictionary m_dictionary;
    
    	public bool Add<TA, TB>(TA key, TB value)
    	{
    		try
    		{
    			if (m_dictionary == null)
    			{
    				m_dictionary = new Dictionary<TA, TB>();
    			}
                //check types before adding, instead of using try/catch
    			m_dictionary.Add(key, value);
    
    			return true;
    		}
    		catch (Exception)
    		{
                //wrong types were added to an existing dictionary
    			return false;
    		}
    	}
    }
