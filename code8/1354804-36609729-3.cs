    XmlSerializer serializer = new XmlSerializer(typeof(ProdutosServicos));
            var productoServices = new ProdutosServicos();
            Produto producto1 = new Produto();
            producto1.Descricao = "Descricao1";
            producto1.Quantidade = "Quantidade1";
            Produto producto2 = new Produto();
            producto2.Descricao = "Descricao2";
            producto2.Quantidade = "Quantidade2";
    
            List<Produto> collectionProducto = new List<Produto>();
            collectionProducto.Add(producto1);
            collectionProducto.Add(producto2);
            productoServices.Produto = collectionProducto;
    
            string xmlString = string.Empty;
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter))
                {
                    serializer.Serialize(writer, productoServices);
                    //String in required format
                    xmlString = stringWriter.ToString(); 
                }
            }
