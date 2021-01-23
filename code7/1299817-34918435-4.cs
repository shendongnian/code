    public void refreshDependencies()
    {
       foreach (Module mod in this.Items)
       {
          int idx = -1;
          switch (mod.ModID)
          { 
             case "SOMEMODID":
                // Mode depends on SOMEOTHERMODID
                idx = this.modList.getItemIndex("SOMEOTHERMODID");
                if (idx != -1)
                {
                   (mod as SomeModule).ModeEn = (this.Items[idx] as SomeOtherModule).SomeOtherProperty;
                }
                else
                {
                   (mod as SomeModule).ModeEn = false;
                }
                break;
          }
       }
    }
