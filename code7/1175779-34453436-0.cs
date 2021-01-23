    CodeAssignStatement body = new CodeAssignStatement();
    body.Left = new CodeFieldReferenceExpression(null, "Propiedad ");
    body.Right = new CodeFieldReferenceExpression(null, "parametro");
    ------------------------------- OUTPUT--------------------------------
    private Metodo(string parametro) {
        Propiedad = parametro;
    }
