    int Calculate(string expression){
        var symbol = expression.First();
        var numbers = expression.SubString(2).Split(' ');
        switch(symbol){
            case '+':
                return numbers.Aggregate((a, b) => (int)a + (int)b));
            case '-':
                return numbers.Aggregate((a, b) => (int)a - (int)b));
            case '*':
                return numbers.Aggregate((a, b) => (int)a * (int)b));                 
            case '/':
                return numbers.Aggregate((a, b) => (int)a / (int)b));        }
    }
