               [HttpPost]
                public ActionResult Salvar()
                {
                  var checkboxkeys = Request.Form.AllKeys.Where(k=>k.Contains("chk_"));
                  var CheckedCheckboxesId =checkboxkeys.Select(k=> Convert.ToInt32( k.Substring(4,k.Length-4)));
        
                  var produtokeys = Request.Form.AllKeys.Where(k=>k.Contains("produto_"));
                  var produtos= new Dictionary<int,string>();
                  foreach(var item in produtokeys )
                  {
                      produtos.Add(Convert.ToInt32( item.Substring(8,k.Length-8)),Request.Form[item]);
                  }
    
    
                  var valorkeys = Request.Form.AllKeys.Where(k=>k.Contains("valor_"));
                  var valors= new Dictionary<int,string>();
                  foreach(var item in valorkeys )
                  {
                      valors.Add(Convert.ToInt32( item.Substring(6,k.Length-6)),Request.Form[item]);
                  }
        
                  // in here you have CheckedCheckboxesId, produtos and valors and you may want store them.
        
                  return RedirectToAction("List");
                }
