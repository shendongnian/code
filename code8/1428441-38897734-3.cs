    button.Click += async delegate
        {
            string param2 = p2EditText.Text;
            var result = await ServiceAccessLayer.GetResponse(param2);
            resultEditText.Text = result;
        };
