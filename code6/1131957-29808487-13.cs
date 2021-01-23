    private void btnSave_Click(object sender, EventArgs e)
    {
        Member member = new Member();
        member.Name = txtName.Text;
        using (container.BeginLifetimeScope()) 
        {
            var memberService = container.GetInstance<IMemberService>();
            memberService.Save(member);
        }
    }
