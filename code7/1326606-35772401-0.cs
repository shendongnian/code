    class MyResult {
        public List<int> MyList { get; set; }
        public string MyString { get; set; }
    }
    
    public MyResult index_selected(arg1..., arg2...) {
       return new MyResult {
          MyList = outputList,
          MyString = "outputString"
       }
    }
