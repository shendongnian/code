           [HttpPost]
            public ActionResult Salvar()
            {
              var checkboxkeys = Request.Form.AllKeys.Where(k=>k.Contains("chk_"));
              var CheckedCheckboxesId =Convert.ToInt32( checkboxkeys.Select(k=> k.Substring(4,k.Length-4)));
    
              // and for produto and valor get data in same way.
    
              return RedirectToAction("List");
            }
