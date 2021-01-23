    public void Update(int id, Product product)
    {
      var request = new RestRequest("Products/" + id, Method.PUT);
      request.AddJsonBody(product);
      client.Execute(request);
    }
