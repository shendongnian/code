public void RadioButtonClickByNameAndValue(string name, string val)
        {
            ScreenComponent.Wait.WaitVisibleElement(By.Name(name));
            ScreenComponent.Script.ExecuteJavaScriptCode($"$('[name={name}][value={val}]').click();");
        }
* In another class I say what value I want to click and in another class I say what is the element.
* in my case the radio options value are "True" and "False".
