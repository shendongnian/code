    Use Like that it will give you more flexibility to get  the data , if you don't know how may level depth you have to search it will become very difficult and code will be look like tightly coupled or hardcoded whenever you working with json or xml follow class structure it will help to debug or understand the structure as well
    
       public class Test{
        public string[] error{get;set;}
        public strinng result{get;set;}
        }
        
        public class Result{
         public List<Values> XETHXXBT{get;set;}
        }
        
        public class Values{
        public List<Double> a{get;set;}
        public List<Double> b{get;set;}
        public List<Double> c{get;set;}
        }
        After that class Jsonconvert.deserializeObject<Test>(jsonString); and store it in object you will proper json data in object and after that you can traaverse and get desired data according to your need.Hope it will help you T
    Thanks
