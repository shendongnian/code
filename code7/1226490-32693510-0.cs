               public ActionResult Part2()
                {
                    List<Employee> list = new List<Employee>();
                    HttpClient client = new HttpClient();
                    var result = client.GetAsync("http://localhost:1963/api/Example").Result;
                    if (result.IsSuccessStatusCode)
                    {
                        list = result.Content.ReadAsAsync<List<Employee>>().Result;
                    }
                    return View(list);
                }
