    using System;
    using System.ComponentModel;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    namespace WpfApp1
    {
    	public class MainViewModel
    	{
    		public ListViewModel MyListViewModel{get;set;}
    		public MainViewModel()
    		{
    			MyListViewModel = new ListViewModel();
    		}
    	}
    
    	public class ListViewModel
    	{
    		public ObservableCollection<ListStruct> Items { get; set; }
    		public ListViewModel()
    		{
    			Items = new ObservableCollection<ListStruct>();
    			Items.Add(new ListStruct { CarName = "Toyota", IsFavorite = true});
    			Items.Add(new ListStruct { CarName = "DongFeng", IsFavorite = false });
    		}	
    	}   
    
    	public class ListStruct
    	{
    		public bool IsFavorite {get;set;}
    		public string CarName {get;set;}
    	}
    }
