     public IActionResult Get(string id)
           {
              var data = _service.getData(id);
              return this.ToPascalCase(data);
            }
