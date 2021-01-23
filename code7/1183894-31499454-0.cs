    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace columm_names
    {
    	public class column
    	{
    		public static void Main()
    		{
    
    			string text = "SELECT ISNULL(DISTINCT COALESCE(ActivityName, 'BLANK'), 'NULLVALUE') AS ActName, ActivityPK Primary, ActCode Code, StartDt as ‘Start Date’, (SELECT ECODE FROM ActBCodes WHERE act.ActBCode_FK=BCodePK) ECode FROM TBL_TMX_Activity act";
    			string s1,s2,text2;
    			string[] last_str,str;
    			int first = text.IndexOf("SELECT") + "SELECT".Length;
    			int last = text.IndexOf("AS");
    			int count=0;
    			int index=0;
    			int x = 1;int i = 0;
    			char[] seperators = { ' ' };
    
    			List<string> column_name = new List<string>();
    			List<string> alias = new List<string>();
    
    			while (text.Length!=0 && last >0)
    			{
    				text2 = sub_string(first,last,text);
    				if (x == 1)
    				{
    					column_name.Add(text2);
    					index = text.IndexOf(text2) + text2.Length+2;text = text.Remove(0, index); 
    					index = text.IndexOf(",");
    					text2 = text.Substring(0, index);
    					alias.Add(text2); x = 0;
    				}
    				else
    				{
    					if (text2.IndexOf("as") > 0)
    					{
    						s1 = sub_string(first,text.IndexOf("as"),text); 
    						column_name.Add(s1);
    						s2 = sub_string (text.IndexOf ("as") + 3, text.IndexOf (","), text);
    						alias.Add(s2);
    					}
    					else
    					{
    						str = text2.Split(seperators); 
    						column_name.Add(str[0]);
    						alias.Add(str[1]);
    					}
    				}
    				index = text.IndexOf(text2) + text2.Length + 1;text = text.Remove(0, index);
    				first =1;
    				last = text.IndexOf(",");
    
    				if (last < 0) 
    				{ 
    					last_str = text.Split(seperators);
    					text2="";
    					while(i<last_str.Length)
    					{
    						if(count == 2){break;}
    						else {if(last_str[i]=="FROM"){count++;index =i;}}
    						i++;
    					}
    
    					for(i=0;i<index-1;i++){text2+=" "+last_str[i];}
    					column_name.Add(text2);
    					alias.Add(last_str[index-1]);break;
    				}
    			}
    			Console.WriteLine ("Column Names"); display (column_name);
    			Console.WriteLine("\n Alias");display (alias);
    		}
    
    		static string sub_string(int x,int y,string z)
    		{
    			string r =z.Substring(x, y-x);
    			return r;
    		}
    
    		static void display(List<string> lst)
    		{	string[] arr = lst.ToArray();
    			foreach(string s in arr){Console.WriteLine (s);Console.ReadLine ();}
    		}
    	}
    
    }
