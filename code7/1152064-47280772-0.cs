      private static Dictionary<int, Action> MethodDictionary(string param1, string param2, int param3) => new Dictionary<int, Action>
        {
                {1 , () =>   Method1(param1, param2, param3) },
                {2 , () =>   Method2(param1, param2, param3) },
                {3 , () =>   Method3(param1, param2, param3) },
                {4 , () =>   Method4(param1, param2, param3) },
                {5 , () =>   Method5(param1, param2, param3) }
        };
