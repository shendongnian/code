    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    
    using System.Collections;
    using System.Diagnostics;
    
    namespace parallelFor
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Stopwatch timer = new Stopwatch();
    			timer.Start();
    			int size = 50000;
    			ArrayList widgets = new ArrayList(size);
    
    			Parallel.For(0, size, i =>
    			{
    				Widget w = new Widget((int)i);
    				widgets.Add(w);
    				w.ProcessWidget();
    			});
    
    
    			timer.Stop();
    
    			Console.WriteLine(timer.Elapsed);
    			Console.ReadLine();
    		}
    	}
    
    	class Widget
    	{
    		public Widget()
    		{
    			this.CreatedDateTime = DateTime.Now;
    		}
    
    		public Widget(int ID)
    			: this()
    		{
    			this.ID = ID;
    		}
    
    		public DateTime CreatedDateTime { get; set; }
    		public int ID { get; set; }
    
    		public void ProcessWidget()
    		{
            int Z = this.ID + this.ID;
            string Message = "Widget ID " + this.ID;
            Message += " was created on ";
            Message += CreatedDateTime.Year + "-" + CreatedDateTime.Month + "-" + CreatedDateTime.Day + ", at ";
            Message += CreatedDateTime.Hour + ":" + CreatedDateTime.Minute + ", with a value of ";
            Message += Z.ToString();
            Console.WriteLine(Message);
    		}
    	}
    }
