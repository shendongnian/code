    else
        {
        context.ObjectTrackingEnabled=false;
       
       // Get the original object
         TB_CLIENTE_CLI clienteOriginal=context.TB_CLIENTE_CLIs.SingleOrDefault(c=>c.ID_CLIENTE_CLI==cliente.ID_CLIENTE_CLI);
         context.TB_CLIENTE_CLIs.Attach(cliente, clienteOriginal);
       }
