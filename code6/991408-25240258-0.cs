    string input = "Lorem ipsum dolor sit amet, %param% consectetur adipiscing elit. Ut placerat risus vitae augue vestibulum imperdiet. Nullam ac urna pellentesque purus hendrerit convallis. Morbi bibendum augue sed mi faucibus, sit amet scelerisque augue interdum. Aenean iaculis lacus ut sapien imperdiet mollis."
    StringBuilder param = new StringBuilder();
    List<string> params = new List<string>();
    bool writingParam = false;
    
    foreach(char c in input) {
      if(!writingParam && c == '%') {
        writingParam = true;
      }
      else if(writingParam) {
        if(c != '%') {
          param.Append(c);
        }
        else {
          params.Add(param.ToString());
          param = new StringBuilder();
          writingParam = false;
        }
      }
    }
