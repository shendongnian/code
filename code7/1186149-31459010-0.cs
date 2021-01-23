    var controller = new UserController()
    var result = controller.productGrid("");
    Assert.IsNotNull(result);
    var viewResult = result as PartialViewResult;
    var hasErrors = controller.ModelState.Values.Any(d => d.Errors.Any());
    Assert.IsFalse(hasErrors);
    Assert.IsInstanceOf<PartialViewResult>(result);
    Assert.IsNotNull(viewResult);
    Assert.AreEqual(true, result.ViewData.Count > 0);
 
