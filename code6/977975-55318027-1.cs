	using FrostyTheSnowman.Models;
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	namespace FrostyTheSnowman
	{
	    public class MainPageViewModel
	    {
	        public User user { get; set; }
	        public MainPageViewModel()
	        {
	            user = new User
	            {
	                FirstName = "Frosty",
	                LastName = "The Snowman"                
	            };
	        }
	    }
	}
