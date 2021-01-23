          Proizvodi p = responseProizvodi.Content.ReadAsAsync<Proizvodi().Result;
          proizvod = p; 
    // do some edit on "proizvod" and put to database
          HttpResponseMessage responseProizvod = proizvodiService.PutResponse(proizvod.ProizvodID,proizvod);
        
    
