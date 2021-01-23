    public bool CheckConsecutiveAlternation(double[] data)
    {
     double[] d = GetDerivative(data);
     var signs = d.Select(v => Math.Sign(v));
     bool isAlternating = 
               signs.Select((s, idx) => new { sign = s, idx = idx })
                    .Skip(1)
                    .All(an => an.sign != signs[an.idx -1]);
    }
     private static double[] GetDerivative(double[] data)
     {
         var d = data.Zip(data.Skip(1), (a, b) => b - a).ToArray();
         return d;
     }
         
