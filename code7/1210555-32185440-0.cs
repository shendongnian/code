    public class ExpressionTransformer<TFrom>
    {
        // ...
        private class InnerExpressionTransformer<TTo>
            where TTo : TFrom
        {
            // ...
        }
    }
