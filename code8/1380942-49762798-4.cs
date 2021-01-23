    public IEnumerable<SelectOption> getOrderTypes()
    {
        List<SelectOption> orderTypes = new List<SelectOption>();
                            if (this.orderType == "OptionText")
                            {
                                orderTypes.Add(new SelectOption() { Value = "1", Text = "OptionText", Selected = true });
                            } else
                            {
                                orderTypes.Add(new SelectOption() { Value = "2", Text = "OptionText2" });
                            }
    }
