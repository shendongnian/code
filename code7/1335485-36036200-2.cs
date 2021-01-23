        if (radAsc.Checked)
        {
            // num += 1: - I've seen odds/even switch on the screenshot
            // so you may want to change/add num += 1 into num += 2
            for (double num = fromNum; num <= toNum; num += 1) {
              lstResult.Items.Add(num);
              total = total + num;
            }
        }
        else
        {
            // Descending order: 
            //   - start from the bottom (toNum)
            //   - loop until the top (fromNum) 
            //   - descend by 1 (num -= 1)
            for (double num = toNum; num >= fromNum; num -= 1) {
              lstResult.Items.Add(num);
              total = total + num;
            }
        }
