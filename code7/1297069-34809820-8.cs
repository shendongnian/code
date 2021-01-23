    using HelloWorldMvcApp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace HelloWorldMvcApp
    {
    	public class HomeController : Controller
    	{
    			public ActionResult Index()
            	{
                MainViewModel oVm = new MainViewModel()
                {
                    Students = new List<Student>() {
                        new Student
                        {
                            ID=1,
                            Name="JoyDev",
                            StateID=1,
                            CityID=1,
                            States=new List<States>()
                            {
                                new States
                                {
                                    ID=1,
                                    Name="WestBengal",
                                },
                                new States
                                {
                                    ID=2,
                                    Name="Bihar",
                                },
                                new States
                                {
                                    ID=3,
                                    Name="Orrisa",
                                }
    
                            },
                            Cities=new List<Cities>()
                            {
                                new Cities
                                {
                                    ID=1,
                                    Name="Alipur"
                                },
                                new Cities
                                {
                                    ID=2,
                                    Name="Asansol"
                                },
                                new Cities
                                {
                                    ID=3,
                                    Name="Andul"
                                }
    
                            }
                        },
    
    //***********
                        new Student
                        {
                            ID=1,
                            Name="Mukti",
                            StateID=2,
                            CityID=1,
                            States=new List<States>()
                            {
                                new States
                                {
                                    ID=1,
                                    Name="WestBengal",
                                },
                                new States
                                {
                                    ID=2,
                                    Name="Bihar",
                                },
                                new States
                                {
                                    ID=3,
                                    Name="Orrisa",
                                }
    
                            },
                            Cities=new List<Cities>()
                            {
                                new Cities
                                {
                                    ID=1,
                                    Name="Janpur"
                                },
                                new Cities
                                {
                                    ID=2,
                                    Name="Madhubani"
                                },
                                new Cities
                                {
                                    ID=3,
                                    Name="Kanti"
                                }
    
                            }
                        },
    //***********
                        new Student
                        {
                            ID=1,
                            Name="Somnath",
                            StateID=3,
                            CityID=2,
                            States=new List<States>()
                            {
                                new States
                                {
                                    ID=1,
                                    Name="WestBengal",
                                },
                                new States
                                {
                                    ID=2,
                                    Name="Bihar",
                                },
                                new States
                                {
                                    ID=3,
                                    Name="Orrisa",
                                }
    
                            },
                            Cities=new List<Cities>()
                            {
                                new Cities
                                {
                                    ID=1,
                                    Name="Chandapur"
                                },
                                new Cities
                                {
                                    ID=2,
                                    Name="Dhankauda"
                                },
                                new Cities
                                {
                                    ID=3,
                                    Name="Konarak"
                                }
    
                            }
                        }
    
    
                    }
    
                };
    
    
                return View(oVm);
            }
    		
    	}
    }
