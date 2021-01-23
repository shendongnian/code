    var html = "<ul>";
    var stack = [];
    var pointer = 0;
    stack.push(0);
        foreach (var c in listWithElements)
        {
            if (stack[pointer]==2){
              html += "</ul>";
              stack.pop();
              pointer--;
            }
            else{
              stack[pointer]++;
            }
            html += "<li>";
            if (c is Question)
            {
                stack.push(0);
                pointer++;
                var v = (Question)c;
                html += v.Content + "<ul>";
               
            }
            else
            {
                var t = (Answer)c;
                html += t.Content + "</li>";
                
            }
        }
    return html + "</ul>";
