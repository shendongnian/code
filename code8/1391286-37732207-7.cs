    [HttpPost]
    public async Task<ActionResult> Form(string Name, string Surname, string Qualification, string Specialty, double Rating) {
    
        Student student = new Student {
            Name = Name,
            Surname = Surname,
            Qualification = Qualification,
            Specialty = Specialty,
            Rating = Rating
        };
        // Here I must send student object to Web Api
        // URL: "http://localhost:2640/api/students"
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:2640/");
        
        var response = await client.PostAsJsonAsync("api/students", student);
        if(response.IsSuccessStatusCode) {
            return RedirectToAction("Index");
        }
        return View(student);
    }
