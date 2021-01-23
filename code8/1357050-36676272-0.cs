    if (viewModel.CartItems.Any())
    {
        ViewBag.CartStatus = "CART EMPTY";
    }
    else
    {
        ViewBag.CartStatus = "Cart Has item, proceed";
    }
