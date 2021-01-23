    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var observableList = new ObservableCollection<string>();
            var syncList = new List<string>(observableList);
    		
            observableList.CollectionChanged += (o,e) => { 
    			foreach (var item in e.NewItems){
    				syncList.Add((string)item);
    			}
    		};
    		observableList.Add("Test");
    		Console.WriteLine(syncList[0]);
    	}
    }
